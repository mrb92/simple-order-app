import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { KeyValueItemModel } from "../../custom-core/common/models/key-value-item.model";
import { CreateOrderModel } from "../models/create-order.model";
import { VehicleFilterModel } from "../models/vehicle-filter.model";
import { VehicleListModel } from "../models/vehicle-list.model";

@Injectable({ providedIn: "root" })
export class NewOrderDataService {

    constructor(private readonly http: HttpClient) { }

    getOrderTypes(): Observable<KeyValueItemModel[]> {
        const http$ = 
            this.http.get<KeyValueItemModel[]>(`/api/orders/types`);

        return http$;
    }

    getVehicleFilters(): Observable<VehicleFilterModel> {
        const http$ =
            this.http.get<VehicleFilterModel>(`/api/vehicles/filters`);
        
        return http$;
    }

    getVehicles(vehicleTypeId: number): Observable<VehicleListModel> {
        const http$ =
            this.http.get<VehicleListModel>(`/api/vehicles?typeId=${vehicleTypeId}`);

        return http$;
    }

    createOrder(createOrderModel: CreateOrderModel): Observable<number> {
        const http$ = 
            this.http.post<number>(`/api/orders`, createOrderModel);
        
        return http$;
    }

}