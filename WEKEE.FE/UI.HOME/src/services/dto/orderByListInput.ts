import { PagedListInput } from "./pagedListInput";

export interface OrderByListInput extends  PagedListInput {
    propertyOrder: string;
    valueOrderBy: string;
}