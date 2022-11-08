export class VehicleOrderDetailModel {
    id: number;
    title: string;
    isTankFull?: boolean;
    isCarIntact?: boolean;
    startDate: Date;
    endDate?: Date;
    total: number;
    pricePerDay: number;
}