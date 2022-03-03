<template>
  <div>
    <div class='p-d-flex p-jc-center'>
      <div class=''>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-key'></i></span>
            <span class='p-float-label'>
              <InputNumber class='inputid' :min='0' v-model.number='id' />
              <label for='inputid'>Código</label>
            </span>
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-user'></i></span>
            <span class='p-float-label'>
              <InputText id='inputname' type='text' v-model='name' />
              <label for='inputname'>Nome</label>
            </span>
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-mobile'></i></span>
            <span class='p-float-label'>
              <InputMask id='inputwhatsApp' v-model='whatsApp' mask='(99) 99999-9999' />
              <label for='inputwhatsApp'>Telefone (WhatsApp)</label>
            </span>
          </div>
        </div>
        <div class=''>
          <div class='p-inputgroup p-mt-4'>
            <span class='p-inputgroup-addon'><i class='pi pi-id-card'></i></span>
            <span class='p-float-label'>
              <InputMask id='inputcpf' v-model='cpf' mask='999.999.999-99' />
              <label for='inputcpf'>CPF</label>
            </span>
          </div>
        </div>
      </div>
    </div>
    <div class='p-d-flex p-jc-center p-mt-4'>
      <Button icon='pi pi-save' iconPos='left' class='p-m-2' label='Save' @click='personSave()' />
      <Button icon='pi pi-user-edit' iconPos='left' class='p-m-2' label='Edit' @click='personEdit()' />
      <Button icon='pi pi-trash' iconPos='left' class='p-m-2' label='Delete' @click='personDelete()' />
    </div>
    <div class='p-d-flex p-align-center p-jc-center p-flex-column p-mt-4'>
      <h2 class='p-text-center'>Pessoas cadastradas</h2>
      <Button type="button" label="Pesquisar" icon="pi pi-refresh" :loading="loading"  @click='getAll()' />
      <Listbox class='p-m-2 p-text-center' style='width: 350px' :options='list' optionLabel='name' @change='change($event)' />
    </div>
  </div>
</template>
<script lang='ts'>
import { defineComponent, inject, onMounted, Ref, ref } from 'vue'
import { Person } from '@/models/Person'
import baseService from '@/service/base.service'
import router from '@/router'


export default defineComponent({
  name: 'personView',
  components: {},
  setup() {
    const storage = inject('storage')
    const list = ref<Array<Person>>([])
    const controller = router.currentRoute.value.path.substring(1)
    const loading = ref(false)
    const id:  Ref<string> | Ref<null> = ref(null)
    const name:  Ref<string> | Ref<null> = ref(null)
    const email:  Ref<string> | Ref<null> = ref(null)
    const whatsApp:  Ref<string> | Ref<null> = ref(null)
    const cpf:  Ref<string> | Ref<null> = ref(null)
    const current = ref<Person>(new Person(id.value, name.value, email.value, whatsApp.value, cpf.value))


    onMounted(async () => {
      await getAll()
    })

    async function getAll() {
      loading.value = true
      baseService(controller).getAll().then((data) => {
        list.value = data as Array<Person>
        setTimeout(() => {
          loading.value = false
        }, 500)
      }).catch((response) => {
        console.log('Erro personGetAll:', response)
        Promise.reject(response)
      })
    }

    async function personSave() {
      await baseService(controller).saveModel(current.value)
    }

    async function personEdit() {
      await baseService(controller).editModel(current.value)
    }

    async function personDelete() {
      await baseService(controller).deleteModel(current.value)
    }

    async function change(event) {
      if(confirm(`Deseja alterar ${event.value.name}?`)){
        await baseService(controller).getById(event.value).then((result)=> {
          id.value = result.id
          name.value = result.name
          whatsApp.value = result.whatsApp
          email.value = result.email
          cpf.value = result.cpf
        })
      }
    }

    return {
      current,
      loading,
      storage,
      list,
      change,
      personDelete,
      personSave,
      personEdit,
      getAll,
      id,
      name,
      email,
      whatsApp,
      cpf
    }
  }
})
</script>

<style scoped>

</style>