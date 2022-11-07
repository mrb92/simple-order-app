import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { OrderTypeEnum } from "../../../custom-core/common/enums/orderTypeEnum";
import { KeyValueItemModel } from "../../../custom-core/common/models/key-value-item.model";
import { CreateOrderModel } from "../../models/create-order.model";
import { NewOrderDataService } from "../../services/new-order-data.service";
import { NewOrderFormService } from "../../services/new-order-form.service";

@Component({
    selector: "app-new-order",
    templateUrl: "./new-order.component.html",
    styleUrls: ["./new-order.component.scss"]
})
export class NewOrderComponent implements OnInit {

    // public data: OrderListModel;
    private currentOrderTypeSubject = new BehaviorSubject<number>(0);

    public orderTypes$: Observable<KeyValueItemModel[]>;
    public OrderTypeEnum = OrderTypeEnum;
    public currentOrderType$ = this.currentOrderTypeSubject.asObservable();

    constructor(public formService: NewOrderFormService,
        private dataService: NewOrderDataService,
        private router: Router) { }

    ngOnInit(): void {
        this.formService.initForm();
        this.initObservables();
        this.listenToFormEvents();
    }

    public onSubmitClick(): void {
        var formValue = this.formService.form.getRawValue();

        const newOrder: CreateOrderModel = {
            customerName: formValue.customerName,
            customerPhone: formValue.customerPhone,
            startDate: new Date(formValue.startDate),
            orderTypeId: +formValue.orderTypeId,
            itemId: +formValue.itemId
        };

        this.dataService.createOrder(newOrder).subscribe((orderId: number) => {
            this.router.navigate(['']);
        });
    }

    private listenToFormEvents(): void {
        this.formService.form.get("orderTypeId")?.valueChanges.subscribe(v => {
            this.currentOrderTypeSubject.next(+v);
        });
    }

    private initObservables(): void {
        this.orderTypes$ = this.dataService.getOrderTypes();
    }

}