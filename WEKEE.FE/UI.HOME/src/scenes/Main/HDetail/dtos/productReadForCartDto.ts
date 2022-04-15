export interface ProductReadForCartDto {
    id: number;
    price: number;
    quantity: number;
    displayOrder: number;
    mainProduct: boolean;
    idImg: number;
    iMGS80x80: string;
    values: string;
    name: string;
}