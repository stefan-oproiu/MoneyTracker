import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '@app/material/material.module';
import { SHARED_DIRECTIVES } from './directives';
import { SHARED_COMPONENTS } from './components';

@NgModule({
  declarations: [
    ...SHARED_COMPONENTS,
    ...SHARED_DIRECTIVES,
  ],
  imports: [
    CommonModule,
    MaterialModule,
  ],
  exports: [
    MaterialModule,
    ...SHARED_COMPONENTS,
    ...SHARED_DIRECTIVES,
  ],
})
export class SharedModule { }
