export class OrderItemModel {
    id: number;
    title: string;
    typeId: number;
    startDate: Date;
    endDate?: Date;
    customerName: string;
}