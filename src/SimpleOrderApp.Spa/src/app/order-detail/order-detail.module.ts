import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { VehicleOrderDetailComponent } from "./components/vehicle-order-detail/vehicle-order-detail.component";
import { OrderDetailRoutingModule } from "./order-detail-routing.module";

@NgModule({
    imports: [SharedModule, OrderDetailRoutingModule],
    declarations: [VehicleOrderDetailComponent],
    exports: [],
    providers: []
})
export class OrderDetailModule {}