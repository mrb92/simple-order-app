import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { OrderListModel } from "../models/order-list.model";
import { OrderListDataService } from "./order-list-data.service";

@Injectable({ providedIn: "root" })
export class OrderListResolver implements Resolve<OrderListModel> {
    
    constructor(private dataService: OrderListDataService) { }

    resolve(): Observable<OrderListModel> | Promise<OrderListModel> | OrderListModel {
        return this.dataService.getOrders();
    }
}