import LoadableComponent from "./../Loadable/index";

export const adminRouters: any = [
  //#region none display
  {
    path: "/admin",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/AdminLayout")
    ),
    isLayout: true,
  },
  {
    path: "/admin",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin")),
  },
  {
    path: "/admin/account",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/AAccount")),
  },
  {
    path: "/admin/setting-role",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/APermission")),
  },
  {
    path: "/admin/data-management",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/AAlbum")),
  },
  {
    path: "/admin/data-management/album",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/AAlbum")),
  },
  {
    path: "/admin/data-management/album/image",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/AAlbum")),
  },
  {
    path: "/admin/product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/AProduct")),
  },
  {
    path: "/admin/category",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/ACategory")),
  },
  {
    path: "/admin/specifications-category",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/ASpeciCate")),
  },
  {
    path: "/admin/system/error",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/SError")),
  },
  //#endregion
];

export const userRouters: any = [
  {
    path: "/user",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/UserLayout")
    ),
    isLayout: true,
  },
  {
    path: "/user/order",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/UOrder")),
  },
  {
    path: "/user/viewed",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/UViewed")),
  },
  {
    path: "/user",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/UHome")),
  },
];

export const supplierRouters: any = [
  {
    path: "/supplier",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/SupplierLayout")
    ),
    isLayout: true,
  },
  {
    path: "/supplier/product",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/SupplierLayout")
    ),
  },
  {
    path: "/supplier/product/new-product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/SuNewProduct")),
  },
  {
    path: "/supplier/store/information",
    exact: true,
    component: LoadableComponent(
      () => import("../../scenes/SuStoreInformation")
    ),
  },
];

export const errorRouters: any = [
  //#region none display
  {
    path: "/error",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/ErrorLayout")
    ),
    isLayout: true,
  },
  //#endregion
  {
    path: "/error",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Exception")),
  },
];

export const appRouters: any = [
  //#region none display
  {
    path: "/",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/AppLayout")
    ),
    isLayout: true,
  },
  {
    path: "/login",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Login")),
  },
  {
    path: "/change-the-password",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Login")),
  },
  {
    path: "/register-an-account",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Login")),
  },
  {
    path: "/forgot-password",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Login")),
  },
  {
    path: "/:n",
    exact: true,
    component: LoadableComponent(
      () => import("../../scenes/HCategoryListProduct")
    ),
  },
  {
    path: "/:name/adsid:i",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/HDetail")),
  },
  {
    path: "/",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Home")),
  },
  //#endregion
];
export const routers = [
  ...adminRouters,
  ...userRouters,
  ...supplierRouters,
  ...errorRouters,
  ...appRouters,
];
