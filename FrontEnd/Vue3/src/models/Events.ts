import { computed } from 'vue'
import { helpers, required } from '@vuelidate/validators'

export class Events {
  public Id?: number | undefined
  public Name: string
  public Category: string
  public StartDay: Date
  public State: string
  constructor(
    Id?,
    Name = '',
    Category= '',
    StartDay= new Date,
    State= ''
  ) {
    this.Id = Id
    this.Name = Name
    this.Category = Category
    this.StartDay = StartDay
    this.State = State
  }
}

export const EventsRules = computed(() => ({
  Name: {
    required: helpers.withMessage('Preenchimento obrigatório', required)
  },
  State: {
    required: helpers.withMessage('Preenchimento obrigatório', required)
  }
}))