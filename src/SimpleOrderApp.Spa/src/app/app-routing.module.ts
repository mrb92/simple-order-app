import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { OrderListComponent } from "./order-list/components/order-list/order-list.component";
import { OrderListResolver } from "./order-list/services/order-list.resolver";

export const routes: Routes = [
    { 
        path: "", 
        pathMatch: "full", 
        component: OrderListComponent, 
        resolve: { data: OrderListResolver },
        loadChildren: () => import("./order-list/order-list.module").then(m => m.OrderListModule)
    },
    {
        path: "new-order",
        loadChildren: () => import("./new-order/new-order.module").then(m => m.NewOrderModule)
    },
    {
        path: "orders",
        loadChildren: () => import("./order-detail/order-detail.module").then(m => m.OrderDetailModule)
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }