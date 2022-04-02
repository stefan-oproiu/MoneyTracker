import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CategoriesLoaderGuard, TimePeriodsLoaderGuard } from '@core/guards';
import { meEffects } from '@core/store';
import { EMPTY_PATH, REPORT_PATH } from '@models';
import { EffectsModule } from '@ngrx/effects';
import { SharedModule, ReportComponent } from '@shared';
import { MeComponent } from './me.component';

const routes: Routes = [
  {
    path: EMPTY_PATH,
    pathMatch: 'full',
    redirectTo: REPORT_PATH,
  },
  {
    path: REPORT_PATH,
    component: ReportComponent,
    canActivate: [CategoriesLoaderGuard, TimePeriodsLoaderGuard],
  },
];

@NgModule({
  declarations: [MeComponent],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    EffectsModule.forFeature(meEffects),
  ],
})
export class MeModule {}
