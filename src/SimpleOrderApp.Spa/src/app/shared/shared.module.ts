import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { FooterComponent } from "./components/footer/footer.component";

import { HeaderComponent } from "./components/header/header.component";
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule, MAT_DATE_FORMATS } from "@angular/material/core";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from "@angular/router";


@NgModule({
    imports: [CommonModule, FormsModule, ReactiveFormsModule, MatDatepickerModule, MatNativeDateModule, MatFormFieldModule, MatInputModule, RouterModule],
    declarations: [HeaderComponent, FooterComponent],
    exports: [CommonModule, FormsModule, ReactiveFormsModule, 
        HeaderComponent, FooterComponent, MatDatepickerModule, MatNativeDateModule, MatFormFieldModule, MatInputModule ],
    providers: [
        {provide: MAT_DATE_FORMATS, useValue: {useUtc: true}},
    ]
})
export class SharedModule {}