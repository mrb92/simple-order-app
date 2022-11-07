import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { NewOrderComponent } from "./components/new-order/new-order.component";
import { VehicleOrderComponent } from "./components/vehicle-order/vehicle-order.component";
import { NewOrderRoutingModule } from "./new-order-routing.module";

@NgModule({
    imports: [SharedModule, NewOrderRoutingModule],
    declarations: [NewOrderComponent, VehicleOrderComponent],
    exports: [],
    providers: []
})
export class NewOrderModule {}