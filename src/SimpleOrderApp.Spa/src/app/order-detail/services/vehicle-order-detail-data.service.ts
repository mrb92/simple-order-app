import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { OrderTypeEnum } from "../../custom-core/common/enums/orderTypeEnum";
import { UpdateVehicleOrderDetailModel } from "../models/update-vehicle-order-detail.model";
import { VehicleOrderDetailModel } from "../models/vehicle-order-detail.model";

@Injectable({ providedIn: "root" })
export class VehicleOrderDetailDataService {

    constructor(private readonly http: HttpClient) { }

    getVehicleOrder(id: number): Observable<VehicleOrderDetailModel> {
        const http$ = 
            this.http.get<VehicleOrderDetailModel>(`/api/orders/${id}?orderTypeId=${OrderTypeEnum.Vehicles}`);

        return http$;
    }

    updateVehicleOrder(updateModel: UpdateVehicleOrderDetailModel): Observable<boolean> {
        const http$ = 
            this.http.put<boolean>(`/api/orders/vehicle-order`, updateModel);
        
        return http$;
    }


}