import { Component, Directive, OnDestroy } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Directive()
export class DestroyableDirective implements OnDestroy {
  private subject: Subject<any> = new Subject();
  protected destroyed$: Observable<any> = this.subject.asObservable();

  ngOnDestroy(): void {
    this.subject.next();
    this.subject.complete();
  }
}
