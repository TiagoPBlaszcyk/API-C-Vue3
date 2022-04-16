<template>
  <div>
    <ConfirmDialog :breakpoints="{'960px': '75vw', '640px': '100vw'}" :style="{width: '50vw'}" />
    <Toast position="top-left" group="save" />
    <Toast position="top-left" group="delete" />
    <Toast position="top-left" group="edit" />
    <div class='p-d-flex p-jc-center'>
      <div class=''>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-user'></i></span>
            <span class='p-float-label'>
              <InputText id='inputname' type='text' v-model='state.name' />
              <label for='inputname'>Nome*</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.name'>
          <div v-for='error of v$.name.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'
            ><i class='pi pi-envelope'></i
            ></span>
            <span class='p-float-label'>
              <InputText id='inputuemails' type='text' v-model='state.emails' />
              <label for='inputemails'>Email*</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.emails'>
          <div v-for='error of v$.emails.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-key'></i></span>
            <span class='p-float-label'>
              <Password id='inputsenha' v-model='state.senha' :weakLabel='`Senha Fraca`' :mediumLabel='`Senha normal`'
                        :strongLabel='`Senha Forte`' toggleMask>
                <template #header>
                  <h3>Nivel de segurança</h3>
                </template>
                <template #footer='sp'>
                  {{ sp.level }}
                  <Divider></Divider>
                  <p class='mt-2'>Sugestão</p>
                  <ul class='pl-2 ml-2 mt-0' style='line-height: 1.5'>
                    <li>Ao menos 1 caractere minusculo</li>
                    <li>Ao menos 1 caractere MAIUSCULO</li>
                    <li>Ao menos 1 número</li>
                    <li>Ao menos 8 characters</li>
                  </ul>
                </template>
              </Password>
              <label for='inputsenha'>Senha*</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.senha'>
          <div v-for='error of v$.senha.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-key'></i></span>
            <span class='p-float-label'>
              <Password id='inputconfirmarSenha' v-model='state.confirmarSenha' :feedback='false' toggleMask />
              <label for='inputconfirmarSenha'>Confirme a Senha*</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.confirmarSenha'>
          <div v-for='error of v$.confirmarSenha.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-unlock'></i></span>
            <span class='p-float-label'>
              <InputText id='inputpermissao' type='text' v-model='state.permissao' />
              <label for='inputpermissao'>Permissao</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.permissao'>
          <div v-for='error of v$.permissao.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'
            ><i class='pi pi-id-card'></i
            ></span>
            <span class='p-float-label'>
              <InputMask
                id='inputcpf'
                v-model='state.cpf'
                mask='999.999.999-99'
              />
              <label for='inputcpf'>CPF</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.cpf'>
          <div v-for='error of v$.cpf.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-mobile'></i></span>
            <span class='p-float-label'>
              <InputMask
                id='inputwhatsApp'
                v-model.number='state.whatsApp'
                mask='(99) 99999-9999'
                :unmask='true'
              />
              <label for='inputwhatsApp'>Telefone (WhatsApp)</label>
            </span>
          </div>
        </div>
        <div :class="{ 'p-error': v$.$invalid }" v-if='v$.whatsApp'>
          <div v-for='error of v$.whatsApp.$silentErrors' :key='error.$message'>
            {{ error.$message }}
          </div>
        </div>
      </div>
    </div>
    <div class='p-d-flex p-jc-center p-mt-4'>
      <Button
        icon='pi pi-save'
        iconPos='left'
        class='p-m-2'
        label='Salvar Novo'
        @click='personSave()'
        v-if='!edit'
      />
      <Button
        icon='pi pi-user-edit'
        iconPos='left'
        class='p-m-2'
        label='Edit'
        @click='personEdit()'
        v-if='edit'
      />
      <Button
        icon='pi pi-trash'
        iconPos='left'
        class='p-m-2'
        label='Delete'
        @click='personDelete()'
        v-if='edit'
      />
    </div>
    <div class='p-d-flex p-align-center p-jc-center p-flex-column p-mt-4'>
      <h2 class='p-text-center'>Pessoas cadastradas</h2>
      <Button
        type='button'
        label='Pesquisar'
        icon='pi pi-refresh'
        :loading='loading'
        @click='confirm2()'
      />
      <p class='p-text-center'>Click para editar ou excluir</p>
      <Listbox
        class='p-m-2 p-text-center'
        style='width: 350px'
        :options='list'
        optionLabel='name'
        @change='change($event)'
      />
    </div>
  </div>
</template>
<script lang='ts'>
import {
  computed,
  defineComponent,
  inject,
  onMounted,
  reactive,
  ref
} from 'vue'
import { Person } from '@/models/Person'
import useVuelidate from '@vuelidate/core'
import { required, email, helpers, sameAs } from '@vuelidate/validators'
import router from '@/router'
import baseService from '@/service/base.service'
import { useToast } from 'primevue/usetoast'
import { useConfirm } from 'primevue/useconfirm'

export default defineComponent({
  name: 'PersonView',
  components: {},
  setup() {
    const storage = inject('storage')
    const list = ref<Array<Person>>([])
    const controller = router.currentRoute.value.path.substring(1)
    const loading = ref()
    const toast = useToast()
    const confirmDialog = useConfirm()
    const showSuccess = () => {
      toast.add({severity:'success', summary: 'Sucesso!', detail:'Salvo em banco de dados', group: 'save', life: 3000})
    }

    const confirm2 = () => {
      confirmDialog.require({
        message: 'Gostaria de remover?',
        header: 'Confirmação de exclusão',
        icon: 'pi pi-info-circle',
        acceptClass: 'p-button-danger',
        accept: () => {
          getAllPersons()
          showSuccess()
        },
        reject: () => {
          toast.add({severity:'error', summary:'Rejeitado', detail:'Recusado', group: 'save', life: 2000})
        }
      })
    }

    const edit = ref(false)
    const state = reactive({
      id: undefined,
      name: null,
      emails: null,
      senha: null,
      confirmarSenha: null,
      permissao: null,
      cpf: null,
      whatsApp: null
    })
    const password = helpers.regex(/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.{8,})/)
    const rules = computed(() => ({
      name: {
        required: helpers.withMessage('Preenchimento obrigatório', required)
      },
      emails: {
        required: helpers.withMessage('Preenchimento obrigatório', required),
        email: helpers.withMessage('Informe um email válido', email)
      },
      senha: {
        required: helpers.withMessage('Preenchimento obrigatório', required),
        password: helpers.withMessage('Senha precisa ser Forte', password)
      },
      confirmarSenha: {
        required: helpers.withMessage('Preenchimento obrigatório', required),
        sameAs: helpers.withMessage('As senhas digitadas não são iguais', sameAs(state.senha))
      }
    }))
    const v$ = useVuelidate(rules, state)

    onMounted(async () => {
      await getAllPersons()
    })

    function resetValues(): void {
      state.id = undefined
      state.name = null
      state.senha = null
      state.confirmarSenha = null
      state.permissao = null
      state.whatsApp = null
      state.emails = null
      state.cpf = null
    }

    async function getAllPersons() {
      loading.value = true
      baseService(controller)
        .getAll()
        .then((data) => {
          list.value = data as Array<Person>
          setTimeout(() => {
            loading.value = false
          }, 100)
        })
        .catch((response) => {
          console.log('Erro personGetAll:', response)
          Promise.reject(response)
        })
    }

    async function personSave() {
      if (!v$.value.$invalid) {
        const current = ref<Person>(
          new Person(
            undefined,
            state.name,
            state.emails,
            state.senha,
            state.permissao,
            state.cpf,
            state.whatsApp
          )
        )
        await baseService(controller)
          .saveModel(current.value)
          .then((data) => {
            list.value.push(data)
            current.value = new Person(undefined, '', '', '', '',0, '')
            resetValues()
          })
      } else {
        alert('Revise o formulario')
      }
    }

    async function personEdit() {
      if(!v$.value.$invalid){
        const current = ref<Person>(
          new Person(
            state.id,
            state.name,
            state.emails,
            state.senha,
            state.permissao,
            state.cpf,
            state.whatsApp
          )
        )
        await baseService(controller)
          .editModel(current.value)
          .then((data) => {
            current.value = new Person(undefined, '', '', '', '',0, '')
            resetValues()
            for (let i = 0; i < list.value.length; i++) {
              if (list.value[i].id == data.id) {
                list.value[i] = data
              }
            }
          })
        edit.value = false
      }else{
        alert('Revise o formulario')
      }
    }

    async function personDelete() {
      if(!v$.value.$invalid){
        const current = ref<Person>(
          new Person(
            state.id,
            state.name,
            state.emails,
            state.senha,
            state.permissao,
            state.cpf,
            state.whatsApp
          )
        )
        await baseService(controller)
          .deleteModel(current.value)
          .then((data) => {
            if (data) {
              for (let i = 0; i < list.value.length; i++) {
                if (list.value[i].id == state.id) {
                  list.value.splice(i, 1)
                }
              }
              current.value = new Person(undefined, '', '', '', '',0, '')
              resetValues()
            }
          })
        edit.value = false
      }else{
        alert('Revise o formulario')
      }
    }

    async function change(event) {
      if (confirm(`Deseja alterar ${event.value.name}?`)) {
        edit.value = true
        await baseService(controller)
          .getById(event.value)
          .then((result) => {
            state.id = result.id
            state.name = result.name
            state.senha = result.senha
            state.confirmarSenha = result.senha
            state.permissao = result.permissao
            state.whatsApp = result.whatsApp
            state.emails = result.email
            state.cpf = result.cpf
          })
      }
    }



    return {
      state,
      v$,
      loading,
      storage,
      list,
      confirm2,
      change,
      personDelete,
      personSave,
      personEdit,
      getAllPersons,
      edit
    }
  }
})
</script>

<style scoped>
::v-deep(.p-password input) {
  width: 15rem;
}
</style>
