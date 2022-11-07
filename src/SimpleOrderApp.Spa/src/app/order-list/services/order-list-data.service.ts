import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { OrderListModel } from "../models/order-list.model";

@Injectable({ providedIn: "root" })
export class OrderListDataService {

    constructor(private readonly http: HttpClient) { }

    getOrders(): Observable<OrderListModel> {
        const http$ = 
            this.http.get<OrderListModel>(`/api/orders`);

        return http$;
    }

}