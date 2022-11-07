import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FooterComponent } from "./components/footer/footer.component";

import { HeaderComponent } from "./components/header/header.component";

@NgModule({
    imports: [CommonModule],
    declarations: [HeaderComponent, FooterComponent],
    exports: [CommonModule, HeaderComponent, FooterComponent],
    providers: []
})
export class SharedModule {}