import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UpdateVehicleOrderDetailModel } from "../../models/update-vehicle-order-detail.model";
import { VehicleOrderDetailModel } from "../../models/vehicle-order-detail.model";
import { VehicleOrderDetailDataService } from "../../services/vehicle-order-detail-data.service";
import { VehicleOrderDetailFormService } from "../../services/verhicler-order-detail-form.service";

@Component({
    selector: "app-vehicle-order-detail",
    templateUrl: "./vehicle-order-detail.component.html",
    styleUrls: ["./vehicle-order-detail.component.scss"]
})
export class VehicleOrderDetailComponent implements OnInit {

    public totalCost: number;
    public data: VehicleOrderDetailModel;

    private orderId: number;

    constructor(public formService: VehicleOrderDetailFormService,
        private dataService: VehicleOrderDetailDataService,
        private route: ActivatedRoute,
        private router: Router) { 
        
        this.orderId = route.snapshot.params["orderId"];
    }

    ngOnInit(): void {
        this.formService.initForm();
        
        this.dataService.getVehicleOrder(this.orderId).subscribe(vehicleOrder => {
            this.data = vehicleOrder;

            this.formService.rehydrateForm(vehicleOrder);
        });

        this.listenToFormEvents();
    }

    public onSubmitClick(): void {
        var formValue = this.formService.form.getRawValue();

        const newOrder: UpdateVehicleOrderDetailModel = {
            id: this.data.id,
            endDate: new Date(formValue.endDate),
            isTankFull: formValue.isTankFull ?? false,
            isCarIntact: formValue.isCarIntact ?? false,
            additionalCost: +formValue.additionalCost
        };

        this.dataService.updateVehicleOrder(newOrder).subscribe(() => {
            this.router.navigate(['']);
        });
    }

    private listenToFormEvents(): void {
        this.formService.form.get("endDate")?.valueChanges.subscribe(v => {
            this.calculateTotal();
        });

        this.formService.form.get("additionalCost")?.valueChanges.subscribe(v => {
            this.calculateTotal();
        });
    }

    private calculateTotal(): void {
        const rawEndDate = this.formService.form.get("endDate")?.value;

        if (!rawEndDate)
            return;
        
        const endDate = new Date(rawEndDate);
        const startDate = new Date(this.data.startDate);

        var diff = Math.abs(endDate.getTime() - startDate.getTime());
        var diffDays = Math.ceil(diff / (1000 * 3600 * 24)); 

        this.totalCost = diffDays * this.data.pricePerDay;

        const additionalCost = this.formService.form.get("additionalCost")?.value;

        if (!additionalCost)
            return;

        this.totalCost += +additionalCost;
    }

}