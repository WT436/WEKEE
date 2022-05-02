import { ResourceReadDto } from "./resourceReadDto";

export interface FtPermissionReadDto extends ResourceReadDto{
    isGranted: boolean

}