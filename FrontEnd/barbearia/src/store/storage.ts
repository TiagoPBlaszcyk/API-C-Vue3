import { reactive, readonly } from 'vue'
// Full realtive
const prop = reactive({
  visibleRight: false,
  visibleLeft: false,
})


// Get and Set readonly
const state = reactive({
  teste: 'Abc123'
})
const setters = {
  setTeste(val: string): void {
    state.teste = val
  }
}
const getters = {
  getTeste(): string {
    return state.teste
  }
}

const methods = {
  upperCaseFirstCharacter(val: string): string {
    return val.charAt(0).toUpperCase() + val.substring(1)
  }
}

export default {
  state: readonly(state),
  prop,
  methods,
  getters,
  setters
}

// Exemplo de computed
// const usoNoVueSetup = computed({
//   get(){
//     return storage.getters.getTeste()
//   },
//   set(val: string){
//     storage.setters.setTeste(val)
//   }
// })