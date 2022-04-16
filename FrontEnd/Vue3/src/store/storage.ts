import { reactive } from 'vue'

// Full realtive
const prop = reactive({
  visible: false,
  newModel: false,
})

const methods = {
  upperCaseFirstCharacter(val: string): string {
    return val.charAt(0).toUpperCase() + val.substring(1)
  }
}

export default {
  prop,
  methods
}