export enum MoneyCategoryType {
  Expense = 0,
  Income = 1,
}

export interface MoneyCategory {
  id: number;
  name: string;
  icon: string;
  type: MoneyCategoryType;
  rowVersion: string;
}
