import {
  Directive,
  OnInit,
  TemplateRef,
  ViewContainerRef,
} from '@angular/core';
import { isAdmin } from '@store/auth';
import { Store } from '@ngrx/store';
import { DestroyableDirective } from '@app/shared/destroyable-directive';
import { filter, take, takeUntil } from 'rxjs/operators';

@Directive({
  selector: '[adminPermission]',
})
export class AdminPermissionDirective implements OnInit {
  constructor(
    private viewContainerRef: ViewContainerRef,
    private template: TemplateRef<any>,
    private store: Store
  ) {}

  ngOnInit(): void {
    this.store
      .select(isAdmin)
      .pipe(
        filter((x) => x),
        take(1)
      )
      .subscribe(() => this.viewContainerRef.createEmbeddedView(this.template));
  }
}
