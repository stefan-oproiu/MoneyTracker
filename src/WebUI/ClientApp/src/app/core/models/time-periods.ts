import { deserializeDate } from '@core/utils';

export interface TimePeriodDTO {
  name: string;
  startDate: string;
  endDate: string;
}

export interface TimePeriod {
  name: string;
  startDate: Date;
  endDate: Date;
}

export function deserializeTimePeriod(dto: TimePeriodDTO): TimePeriod {
  return {
    name: dto.name,
    startDate: deserializeDate(dto.startDate),
    endDate: deserializeDate(dto.endDate),
  };
}
