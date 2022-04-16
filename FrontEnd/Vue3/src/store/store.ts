import { ref } from 'vue'
import { defineStore } from 'pinia'
import { EToastSeverity } from '@/Enums/ToastSeverity'

export type Toast = {
  severity: 'success' | 'info' | 'warn' | 'error',
  summary: string,
  detail: string,
  group: string,
  life: number
}

export const useStore = defineStore('store', () => {
  const prop: any = ref({
    visible: false,
    newModel: false,
    toast: null,
    toastMessage: {
      severity: EToastSeverity.Success,
      summary: 'Sucesso',
      detail: 'Salvo com sucesso!',
      group: 'main',
      life: 3000
    } as Toast
  })
  const methods = {
    upperCaseFirstCharacter(val: string): string {
      return val.charAt(0).toUpperCase() + val.substr(1)
    },
    /**
     * Altera o Array@arr do indice atual @from para o indice @to
     * @example
     *  let arr = [1,2,4,5,6,7,8,9,10,3];
     *  arr = changePosition(arr, 9, 3);
     *  console.log(arr); // [1,2,3,4,5,6,7,8,9,10]
     *
     * @param arr Array alvo
     * @param from Indice atual
     * @param to Indice desejado
     */
    changePosition<T>(arr: Array<T>, from: number, to: number): Array<T> {
      arr.splice(to, 0, arr.splice(from, 1)[0])
      return arr
    },
    /**
     * @example
     * const example = useToast()
     * exemplo(toastMessage(EToastSeverity.Success, 'Message', 'Conteudo', 'main', 3000))
     * @param {string} severity Estilo de layout da mensagem
     * @param {string} summary Título da mensagem
     * @param {string} detail Conteúdo corpo da mensagem
     * @param {string} group Nome do grupo na TAG do Toast
     * @param {number} life [optional] Tempo em ms que o Toast permanecerá ativo na tela
     */
    toastMessage(severity: EToastSeverity, summary: string,
                 detail: string, group = 'main', life = 3000): Toast {
      return { severity: severity, summary: summary, detail: detail, group: group, life: life } as Toast
    }
  }

  return { prop, methods }
})
