<template>
  <div>
    <div
      class='p-d-flex p-justify-start p-align-center p-flex-column'
      style='height: 100vh'
    >
      <h1>Eventos</h1>
      <div>
        <DataTable
          :value='data'
          responsiveLayout='scroll'
          v-model:selection='selected'
          v-model:filters='filters'
          filterDisplay='menu'
          selectionMode='single'
          dataKey='Id'
          @rowSelect='rowSelect($event)'
        >
          <template #header>
            <div class='flex justify-content-between'>
              <span class='p-input-icon-left p-float-label'>
                <i class='pi pi-search' />
                <InputText id='idFilters' v-model="filters['global'].value" />
                <label for='idFilters'>Filtrar</label>
              </span>
              <Button
                icon='pi pi-save'
                iconPos='right'
                class='p-ml-2'
                label='Adicionar'
                @click='newEvent()'
              />
            </div>
          </template>
          <template #empty>
            Sem resultados encontrados.
          </template>
          <template #loading>
            Loading customers data. Please wait.
          </template>
          <Column
            v-for='col of columns'
            :field='col.field'
            :header='col.header'
            :key='col.field'
            :sortable="true"
          ></Column>
        </DataTable>
      </div>
    </div>
    <Sidebar
      id='new'
      v-model:visible='store.prop.visible'
      :position='store.prop.newModel? `left`:`right`'
      @hide='store.prop.newModel = false'
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
                        selectionMode='single'
                        :showWeek='true'
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
          <Button class='p-mb-3' :label='store.prop.newModel ? `Salvar` : `Editar`'
                  @click='store.prop.newModel ? saveEvent() : editEvent()' />
          <Button class='p-mb-3' label='Excluir' v-if='!store.prop.newModel' @click='deleteEvent()' />
          <Button label='Cancelar' @click='store.prop.visible = false; store.prop.newModel = false' />
        </div>
      </div>
    </Sidebar>
  </div>
</template>

<script lang='ts'>
import { defineComponent, onMounted, Ref, ref } from 'vue'
import { useConfirm } from 'primevue/useconfirm'
import { Events, EventsRules } from '@/models/Events'
import useVuelidate from '@vuelidate/core'
import baseService from '@/service/base.service'
import { useStore } from '@/store/store'
import { EToastSeverity } from '@/Enums/ToastSeverity'
import { EStatus } from '@/Enums/Status'
import { FilterMatchMode } from 'primevue/api'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    const columns = ref([
      { field: 'Id', header: 'Código' },
      { field: 'Name', header: 'Nome' },
      { field: 'Category', header: 'Categoria' },
      { field: 'StartDay', header: 'Data' },
      { field: 'State', header: 'Status' }
    ])
    const status = [
      { id: 1, state: EStatus.Aberto },
      { id: 2, state: EStatus.Cancelado },
      { id: 3, state: EStatus.Concluido }
    ]
    const store = useStore()
    const controller = 'Events'
    const events = ref()
    const v$ = useVuelidate(EventsRules, events)
    const confirmDialog = useConfirm()
    const data: Ref<Array<Events>> = ref<Array<Events>>([])
    const filters = ref({ global: { value: '', matchMode: FilterMatchMode.CONTAINS } })
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
            store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Success, 'Erro', 'Errro!', 'main', 2000)
          })
    }

    const rowSelect = async (event) => {
      await baseService(controller)
        .getById(event.data)
        .then((result) => {
            result['StartDay'] = new Date(result['StartDay']).toLocaleDateString()
            events.value = result as Events
            store.prop.visible = true
          },
          () => {
            store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Errro!', 'main', 2000)
          })
    }

    const saveEvent = async () => {
      if (!v$.value.$invalid) {
        await baseService(controller)
          .saveModel(events.value as Events)
          .then(() => {
              store.prop.newModel = false
              store.prop.visible = false
              events.value = new Events()
              getAll()
            },
            () => {
              store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Errro!', 'main', 2000)
            })
      } else {
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Warn, 'Campos Inválidos', 'Revise o formulario', 'main', 2000)
      }
    }
    const deleteEvent = async () => {
      await baseService(controller)
        .deleteModel(events.value)
        .then(() => {
            store.prop.visible = false
            getAll()
          },
          () => {
            store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Erro', 'main', 2000)
          })
    }
    const editEvent = async () => {
      if (!v$.value.$invalid) {
        events.value['StartDay'] = new Date(events.value['StartDay']).toJSON()
        await baseService(controller)
          .editModel(events.value)
          .then(() => {
              store.prop.visible = false
              events.value = new Events()
              getAll()
            },
            () => {
              store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Erro', 'main', 2000)
            })
      } else {
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Warn, 'Campos Inválidos', 'Revise o formulario', 'main', 2000)
      }
    }

    const newEvent = () => {
      events.value = new Events()
      store.prop.visible = true
      store.prop.newModel = true
    }

    return {
      store,
      v$,
      newEvent,
      getAll,
      rowSelect,
      confirmDialog,
      selected,
      filters,
      status,
      data,
      saveEvent,
      editEvent,
      deleteEvent,
      events,
      columns
    }
  }
})
</script>
