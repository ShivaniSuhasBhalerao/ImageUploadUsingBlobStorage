import { RoutesService, eLayoutType } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const APP_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routesService: RoutesService) {
  return () => {
    routesService.add([
      {
        path: '/',
        name: '::Menu:Home',
        iconClass: 'fas fa-home',
        order: 1,
        layout: eLayoutType.application,
      },{
        path: '/book',
        name: 'Book',
        iconClass: 'fas fa-home',
        order: 2,
        layout: eLayoutType.application,
      },
      {
        path: '/forgotpassword',
        name: 'Forgot Password',
        iconClass: 'fas fa-home',
        order: 3,
        layout: eLayoutType.application,
      },
      {
        path: '/resetpassword',
        name: 'Reset Password',
        iconClass: 'fas fa-home',
        order: 4,
        layout: eLayoutType.application,
      },
      
    ]);
  };
}
