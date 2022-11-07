import { Injectable } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, Validators } from "@angular/forms";

@Injectable({ providedIn: "root" })
export class NewOrderFormService {
    public form: FormGroup;

    constructor(private readonly fb: FormBuilder) { }

    public initForm(): void {
        this.buildForm();
    }

    private buildForm(): void {
        this.form = this.fb.group({
            customerName: new FormControl("", [Validators.required, Validators.maxLength(250)]),
            customerPhone: new FormControl("", [Validators.required, Validators.maxLength(150)]),
            startDate: new FormControl(null),
            orderTypeId: new FormControl(null),
            itemId: new FormControl(null)
        });
    }

}