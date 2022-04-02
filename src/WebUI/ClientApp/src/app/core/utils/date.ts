export function deserializeDate(date: string): Date {
  return new Date(Date.parse(date));
}
