import { PagedListInput } from "./pagedListInput";

export interface OrderByListInput extends  PagedListInput {
    property: string;
    orderBy: string;
}