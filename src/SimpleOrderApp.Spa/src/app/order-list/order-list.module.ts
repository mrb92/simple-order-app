import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { OrderListComponent } from "./components/order-list/order-list.component";

@NgModule({
    imports: [SharedModule],
    declarations: [OrderListComponent],
    exports: [OrderListComponent],
    providers: []
})
export class OrderListModule {}