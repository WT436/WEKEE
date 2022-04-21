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
  // {
  //   path: "/admin",
  //   exact: true,
  //   component: LoadableComponent(() => import("../../scenes/Admin")),
  // },
  {
    path: "/admin/account",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/Account")),
  },
  {
    path: "/admin/setting-role",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/APermission")),
  },
  {
    path: "/admin/data-management",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/AAlbum")),
  },
  {
    path: "/admin/data-management/album",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/AAlbum")),
  },
  {
    path: "/admin/data-management/album/image",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/AAlbum")),
  },
  {
    path: "/admin/product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/AProduct")),
  },
  {
    path: "/admin/category",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/ACategory")),
  },
  {
    path: "/admin/category/home-page",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/ACategoryHomePage")),
  },
  {
    path: "/admin/specifications-category",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/ASpeciCate")),
  },
  {
    path: "/admin/attribute-product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Admin/AttributeProduct")),
  },
  {
    path: "/admin/system/error",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/System/SError")),
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
    component: LoadableComponent(() => import("../../scenes/User/UOrder")),
  },
  {
    path: "/user/viewed",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/User/UViewed")),
  },
  {
    path: "/user",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/User/UHome")),
  },
];

export const supplierRouters: any = [
  {
    path: "/store",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/SupplierLayout")
    ),
    isLayout: true,
  },
  {
    path: "/store/product",
    exact: true,
    component: LoadableComponent(
      () => import("../../components/Layout/SupplierLayout")
    ),
  },
  {
    path: "/store/product/new-product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Store/SuNewProduct")),
  },
  {
    path: "/store/product/my-product",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Store/MyProductStore")),
  },
  {
    path: "/store/store/information",
    exact: true,
    component: LoadableComponent(
      () => import("../../scenes/Store/SuStoreInformation")
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
    component: LoadableComponent(() => import("../../scenes/System/Exception")),
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
    component: LoadableComponent(() => import("../../scenes/Permission/Login")),
  },
  {
    path: "/change-the-password",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Permission/Login")),
  },
  {
    path: "/register-an-account",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Permission/Login")),
  },
  {
    path: "/forgot-password",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Permission/Login")),
  },
  {
    path: "/:n",
    exact: true,
    component: LoadableComponent(
      () => import("../../scenes/Main/HCategoryListProduct")
    ),
  },
  {
    path: "/:name/adsid:i",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Main/HDetail")),
  },
  {
    path: "/",
    exact: true,
    component: LoadableComponent(() => import("../../scenes/Main/Home")),
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
