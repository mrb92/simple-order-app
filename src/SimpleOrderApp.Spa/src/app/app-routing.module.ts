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
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }