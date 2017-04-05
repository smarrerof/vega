import { IModel } from './model';

export interface IMake {
  id: number;
  name: string;
  models: IModel[];
}