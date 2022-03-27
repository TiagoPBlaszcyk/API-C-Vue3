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
        @click='storage.prop.visibleLeft = true'
      />
      <div>
        <DataTable
          :value='products'
          responsiveLayout='scroll'
          v-model:selection='selected'
          selectionMode='single'
          dataKey='Id'
          @rowSelect='storage.prop.visibleRight = true'
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
      id='edit'
      v-model:visible='storage.prop.visibleRight'
      position='right'
    >
      <h5>{{ selected }}</h5>
    </Sidebar>
    <Sidebar
      id='new'
      v-model:visible='storage.prop.visibleLeft'
      position='left'
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
                        dateFormat="dd/mm/yy"
                        selectionMode="single"
                        :showIcon="true"
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
          <Button class='p-mb-3' label='Salvar' @click='saveEvent' />
          <Button label='Cancelar' @click='storage.prop.visibleLeft = false' />
        </div>
      </div>
    </Sidebar>
  </div>
</template>

<script lang='ts'>
import { defineComponent, inject, onMounted, ref } from 'vue'
import { useToast } from 'primevue/usetoast'
import { useConfirm } from 'primevue/useconfirm'
import { Events, EventsRules } from '@/models/Events'
import useVuelidate from '@vuelidate/core'
import baseService from '@/service/base.service'

export default defineComponent({
  name: 'HomeView',
  components: {},
  setup() {
    const storage: any = inject('storage')
    const controller = 'Events'
    const events = ref(new Events())
    const v$ = useVuelidate(EventsRules, events.value)
    const status = [
      { id: 1, state: 'Aberto' },
      { id: 2, state: 'Cancelado' },
      { id: 3, state: 'Concluído' }
    ]
    const toast = useToast()
    const confirmDialog = useConfirm()
    const data = ref([
      {
        id: 1009,
        name: 'Gaming Set',
        category: 'Electronics',
        date: '25/10/2010',
        state: 'DONE'
      }
    ])
    const products = ref(data)
    const selected = ref()

    const columns = ref([
      { field: 'Id', header: 'Código' },
      { field: 'Name', header: 'Name' },
      { field: 'Category', header: 'Categoria' },
      { field: 'Date', header: 'Data' },
      { field: 'State', header: 'Status' }
    ])

    onMounted(() => {
      getAll()
    })
    const getAll = async () => {
      await baseService(controller)
        .getAll()
        .then((result) => {
            console.log(result)
            data.value = result
          },
          () => {
            toast.add({ severity: 'error', summary: 'Erro', detail: 'Errro!', group: 'erro', life: 1000 })
          })
    }


    const saveEvent = async () => {
      if (!v$.value.$invalid) {
        console.log('Eveent', events.value)
        await baseService(controller)
          .saveModel(events.value)
          .then((result) => {
              console.log(result)
              storage.prop.visibleLeft = false
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
      confirmDialog,
      selected,
      status,
      saveEvent,
      events,
      columns,
      products
    }
  }
})
</script>
