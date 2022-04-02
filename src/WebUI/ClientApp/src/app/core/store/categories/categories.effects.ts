import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { errorMessageValue, MoneyCategory } from '@models';
import { CategoriesService } from '@services';
import { catchError, map, mergeMap } from 'rxjs/operators';
import * as actions from './categories.actions';

@Injectable()
export class MeCategoriesEffects {
  constructor(
    private actions$: Actions,
    private categoriesService: CategoriesService
  ) {}

  getMoneyCategories$ = createEffect(() =>
    this.actions$.pipe(
      ofType(actions.getCategories),
      mergeMap(() => this.categoriesService.getCategories()),
      map((categories: MoneyCategory[]) =>
        actions.getCategoriesSuccess({ categories })
      ),
      catchError((error) => [
        actions.getCategoriesError({ errorMessage: errorMessageValue(error) }),
      ])
    )
  );
}
