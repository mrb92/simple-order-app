import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NewOrderComponent } from "./components/new-order/new-order.component";

const routes: Routes = [
    {
        path: "", 
        pathMatch: "full",
        component: NewOrderComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class NewOrderRoutingModule { }