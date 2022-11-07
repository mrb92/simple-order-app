import { Component, Input, OnInit } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { map, Observable } from "rxjs";
import { KeyValueItemModel } from "../../../custom-core/common/models/key-value-item.model";
import { VehicleFilterModel } from "../../models/vehicle-filter.model";
import { VehicleListModel } from "../../models/vehicle-list.model";
import { NewOrderDataService } from "../../services/new-order-data.service";

@Component({
    selector: "app-vehicle-order",
    templateUrl: "./vehicle-order.component.html",
    styleUrls: ["./vehicle-order.component.scss"]
})
export class VehicleOrderComponent implements OnInit {

    @Input() form: FormGroup

    public vehicleFilters$: Observable<VehicleFilterModel>;
    public data: VehicleListModel;

    constructor(private dataService: NewOrderDataService) { }

    ngOnInit(): void {
        this.initObservables();
    }

    private initObservables(): void {
        this.vehicleFilters$ = this.dataService.getVehicleFilters();
    }

    public onVehicleTypeChange(event: Event): void {
        // @ts-ignore
        const vehicleTypeId: number = +event.target.value;

        this.dataService.getVehicles(vehicleTypeId).subscribe(data => {
            this.data = data
        });
    }

}