<template>
  <div>
    <Toast position='top-center' group='save' />
    <Toast position='top-center' group='erro' />
    <Toast position='top-center' group='info' />
    <div
      class='p-d-flex p-justify-start p-align-center p-flex-column'
      style='height: 100vh'
    >
      <h1>Eventos</h1>
      <Button
        icon='pi pi-save'
        iconPos='right'
        class='p-mt-3'
        label='Adicionar'
        @click='storage.prop.visible = true; storage.prop.newModel = true'
      />
      <div>
        <DataTable
          :value='products'
          responsiveLayout='scroll'
          v-model:selection='selected'
          selectionMode='single'
          dataKey='Id'
          @rowSelect='getById($event)'
        >
          <Column
            v-for='col of columns'
            :field='col.field'
            :header='col.header'
            :key='col.field'
          ></Column>
        </DataTable>
        <Button class='p-mb-3' label='Atualizar' @click='getAll' />
      </div>
    </div>
    <Sidebar
      id='new'
      v-model:visible='storage.prop.visible'
      :position='storage.prop.newModel? `left`:`right`'
      @hide='storage.prop.newModel = false'
    >
      <div class='p-d-flex p-flex-column p-mb-2 p-mt-2 '>
        <div class=''>
          <div class='p-mt-4'>
            <span class='p-float-label'>
              <InputText id='inputName' type='text' v-model='events.Name' />
              <label for='inputName'>Nome*</label>
            </span>
          </div>
          <div :class="{ 'p-error': v$.$invalid }" v-if='v$.Name'>
            <div v-for='error of v$.Name.$silentErrors' :key='error.$message'>
              {{ error.$message }}
            </div>
          </div>
        </div>

        <div class=''>
          <div class='p-mt-4'>
            <span class='p-float-label'>
              <InputText id='inputCategoria' type='text' v-model='events.Category' />
              <label for='inputCategoria'>Categoria</label>
            </span>
          </div>
        </div>

        <div class=''>
          <div class='p-mt-4'>
            <span class='p-float-label'>
              <Calendar id='inputData'
                        v-model='events.StartDay'
                        dateFormat='dd/mm/yy'
                        selectionMode='single'
                        :showIcon='true'
              />
              <label for='inputData'>Data</label>
            </span>
          </div>
        </div>

        <div class=''>
          <div class='p-mt-4'>
            <Dropdown v-model='events.State'
                      id='inputStatus'
                      :options='status'
                      optionLabel='state'
                      optionValue='state'
                      placeholder='Selecione' />
          </div>
          <div :class="{ 'p-error': v$.$invalid }" v-if='v$.State'>
            <div v-for='error of v$.State.$silentErrors' :key='error.$message'>
              {{ error.$message }}
            </div>
          </div>
        </div>
        <div class='p-d-flex p-flex-column p-mt-4'>
          <Button class='p-mb-3' :label='storage.prop.newModel ? `Salvar` : `Editar`' @click='storage.prop.newModel ? saveEvent() : editEvent()' />
          <Button label='Cancelar' @click='storage.prop.visible = false; storage.prop.newModel = false' />
        </div>
      </div>
    </Sidebar>
  </div>
</template>

<script lang='ts'>
import { defineComponent, inject, onMounted, Ref, ref } from 'vue'
import { useToast } from 'primevue/usetoast'
import { useConfirm } from 'primevue/useconfirm'
import { Events, EventsRules } from '@/models/Events'
import useVuelidate from '@vuelidate/core'
import baseService from '@/service/base.service'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    const columns = ref([
      { field: 'Id', header: 'Código' },
      { field: 'Name', header: 'Name' },
      { field: 'Category', header: 'Categoria' },
      { field: 'StartDay', header: 'Data' },
      { field: 'State', header: 'Status' }
    ])
    const status = [
      { id: 1, state: 'Aberto' },
      { id: 2, state: 'Cancelado' },
      { id: 3, state: 'Concluído' }
    ]
    const storage: any = inject('storage')
    const controller = 'Events'
    const events = ref(new Events())
    const v$ = useVuelidate(EventsRules, events.value)
    const toast = useToast()
    const confirmDialog = useConfirm()
    const data: Ref<Array<Events>> = ref <Array<Events>>([])
    const products = ref(data)
    const selected = ref()


    onMounted(() => {
      getAll()
    })
    const getAll = async () => {
      await baseService(controller)
        .getAll()
        .then((result) => {
            for (const resultKey in result) {
              result[resultKey]['StartDay'] = new Date(result[resultKey]['StartDay'])
                .toLocaleDateString('pt-BR', { year: 'numeric', month: '2-digit', day: '2-digit' })
            }
            data.value = result as Array<Events>
          },
          () => {
            toast.add({ severity: 'error', summary: 'Erro', detail: 'Errro!', group: 'erro', life: 1000 })
          })
    }

    const getById = async (event) => {
      await baseService(controller)
        .getById(event.data)
        .then((response) => {
            console.log('byId', response)
            events.value = response
            storage.prop.visible = true
          },
          () => {
            toast.add({ severity: 'error', summary: 'Erro', detail: 'Errro!', group: 'erro', life: 1000 })
          })
    }

    const saveEvent = async () => {
      if (!v$.value.$invalid) {
        await baseService(controller)
          .saveModel(events.value as Events)
          .then(() => {
              storage.prop.newModel = false
              storage.prop.visible = false
              events.value = new Events()
              toast.add({
                severity: 'success',
                summary: 'Sucesso!',
                detail: 'Salvo em banco de dados',
                group: 'save',
                life: 1000
              })
            },
            () => {
              toast.add({ severity: 'error', summary: 'Erro', detail: 'Errro!', group: 'erro', life: 1000 })
            })
      } else {
        toast.add({ severity: 'error', summary: 'Erro', detail: 'Revise o formulario', group: 'erro', life: 3000 })
      }
    }
    const editEvent = async () => {
      if (!v$.value.$invalid) {
        await baseService(controller)
          .editModel(events.value)
          .then((result) => {
              console.log(result)
              storage.prop.visible = false
              events.value = new Events()
              toast.add({
                severity: 'success',
                summary: 'Sucesso!',
                detail: 'Salvo em banco de dados',
                group: 'save',
                life: 1000
              })
            },
            () => {
              toast.add({ severity: 'error', summary: 'Erro', detail: 'Errro!', group: 'erro', life: 1000 })
            })
      } else {
        toast.add({ severity: 'error', summary: 'Erro', detail: 'Revise o formulario', group: 'erro', life: 3000 })
      }
    }

    return {
      storage,
      v$,
      toast,
      getAll,
      getById,
      confirmDialog,
      selected,
      status,
      saveEvent,
      editEvent,
      events,
      columns,
      products
    }
  }
})
</script>
