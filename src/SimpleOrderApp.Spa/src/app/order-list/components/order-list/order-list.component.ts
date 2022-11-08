import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Data } from "@angular/router";
import { OrderTypeEnum } from "../../../custom-core/common/enums/orderTypeEnum";
import { OrderListModel } from "../../models/order-list.model";

@Component({
    selector: "app-order-list",
    templateUrl: "./order-list.component.html",
    styleUrls: ["./order-list.component.scss"]
})
export class OrderListComponent implements OnInit {

    public data: OrderListModel;
    public OrderTypeEnum = OrderTypeEnum;

    constructor(private route: ActivatedRoute) { }

    ngOnInit(): void {
        this.route.data.subscribe((routeData: Data) => {
            this.data = routeData["data"];

            console.log(this.data);
        });
    }

}