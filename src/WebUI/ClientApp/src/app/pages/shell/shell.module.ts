import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  ACCESS_DENIED_PATH,
  EMPTY_PATH,
  ME_PATH,
  NOT_FOUND_PATH,
} from '@models';
import { SharedModule } from '@shared';
import { Routes, RouterModule } from '@angular/router';
import { ShellComponent } from './shell.component';
import { NotFoundComponent, AccessDeniedComponent, SHELL_PAGES } from './pages';
import { CategoriesLoaderGuard, UserCheckGuard } from '@core/guards';

const routes: Routes = [
  {
    path: EMPTY_PATH,
    component: ShellComponent,
    children: [
      {
        path: EMPTY_PATH,
        pathMatch: 'full',
        redirectTo: ME_PATH,
      },
      {
        path: ME_PATH,
        loadChildren: () => import('./pages').then((m) => m.MeModule),
        canActivate: [UserCheckGuard],
      },
      {
        path: NOT_FOUND_PATH,
        component: NotFoundComponent,
      },
      {
        path: ACCESS_DENIED_PATH,
        component: AccessDeniedComponent,
      },
      {
        path: '**',
        redirectTo: NOT_FOUND_PATH,
      },
    ],
  },
];

@NgModule({
  declarations: [ShellComponent, ...SHELL_PAGES],
  imports: [CommonModule, SharedModule, RouterModule.forChild(routes)],
})
export class ShellModule {}
