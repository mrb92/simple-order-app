import { Injectable } from "@angular/core";
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { VehicleOrderDetailModel } from "../models/vehicle-order-detail.model";

@Injectable({ providedIn: "root" })
export class VehicleOrderDetailFormService {
    public form: FormGroup;

    constructor(private readonly fb: FormBuilder) { }

    public initForm(): void {
        this.buildForm();
    }

    private buildForm(): void {
        this.form = this.fb.group({
            id: new FormControl(null),
            endDate: new FormControl(null),
            isTankFull: new FormControl(null),
            isCarIntact: new FormControl(null),
            additionalCost: new FormControl(null)
        });
    }

    public rehydrateForm(model: VehicleOrderDetailModel): void {
        const newFormValue = {
            id: model.id,
            endDate: model.endDate,
            isTankFull: model.isTankFull,
            isCarIntact: model.isCarIntact
        };

        this.form.patchValue(newFormValue);
    }

}