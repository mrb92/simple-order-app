import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { VehicleOrderDetailComponent } from "./components/vehicle-order-detail/vehicle-order-detail.component";

const routes: Routes = [
    {
        path: ":orderId/vehicle", 
        pathMatch: "full",
        component: VehicleOrderDetailComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class OrderDetailRoutingModule { }