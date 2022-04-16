<template>
  <div>
    <div
      class='p-d-flex p-justify-start p-align-center p-flex-column'
      style='height: 100vh'
    >
      <h1>Eventos</h1>
      <div>
        <Button
          icon='pi pi-save'
          iconPos='right'
          class='p-mt-3'
          label='Adicionar'
          @click='newEvent()'
        />
        <Button class='p-ml-2' label='Atualizar' @click='getAll' />
      </div>
      <div>
        <DataTable
          :value='data'
          responsiveLayout='scroll'
          v-model:selection='selected'
          selectionMode='single'
          dataKey='Id'
          @rowSelect='rowSelect($event)'
        >
          <Column
            v-for='col of columns'
            :field='col.field'
            :header='col.header'
            :key='col.field'
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
          <Button class='p-mb-3' :label='store.prop.newModel ? `Salvar` : `Editar`'
                  @click='store.prop.newModel ? saveEvent() : editEvent()' />
          <Button label='Cancelar' @click='store.prop.visible = false; store.prop.newModel = false' />
          <Button label='Excluir' v-if='!store.prop.newModel' @click='deleteEvent()' />
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
    const store = useStore()
    const controller = 'Events'
    const events = ref()
    const v$ = useVuelidate(EventsRules, events)
    const confirmDialog = useConfirm()
    const data: Ref<Array<Events>> = ref<Array<Events>>([])
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
            },
            () => {
              store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Errro!', 'main', 2000)
            })
      } else {
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Campos Inválidos', 'Revise o formulario', 'main', 2000)
      }
    }
    const deleteEvent = async () => {
      await baseService(controller)
        .deleteModel(events.value)
        .then(() => {
            store.prop.visible = false
          },
          () => {
            store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Erro', 'main', 2000)
          })
    }
    const editEvent = async () => {
      if (!v$.value.$invalid) {
        await baseService(controller)
          .editModel(events.value)
          .then(() => {
              store.prop.visible = false
              events.value = new Events()
            },
            () => {
              store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Erro', 'Erro', 'main', 2000)
            })
      } else {
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Campos Inválidos', 'Revise o formulario', 'main', 2000)
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
