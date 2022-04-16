import services from './'
import { useStore } from '@/store/store'
import { EToastSeverity } from '@/Enums/ToastSeverity'
export default (service: string) => {
  const baseUrl = 'api/v1/'
  const store = useStore()

  const getById = async (model) => {
    return await services().get(`${baseUrl + service}/${model.Id}`)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Get: id enviada ->', model.Id)
        console.log('Erro get catch (error)', error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
      })
  }

  const getAll = async () => {
    return await services()
      .get(`${baseUrl + service}`)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Get: ALL')
        console.log('Erro getALL catch (error)', error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
      })
  }

  const saveModel = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
          console.log(response)
        if(response.status == 200){
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Success, 'Sucesso!', 'Salvo em banco de dados', 'main', 2000)
        }
          return response.data
        })
      .catch((error) => {
        console.log('Post: Model enviada ->', model)
        console.log('Erro Save catch (error)', error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Save', error, 'main', 3000)
      })
  }

  const login = async (model) => {
    return await services()
      .post(`${baseUrl + service}`, model)
      .then((response) => {
        return response.data
      })
      .catch((error) => {
        console.log('Login: Model enviada ->', model,error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Login', error, 'main', 3000)
      })
  }

  const newPerson = async (model) => {
    return await services()
      .post(`${baseUrl + service}/Cadastro`, model)
      .then((response) => {
        if(response.status == 201) {
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Info, 'Falha!', response.data.detail, 'main', 3000)
        }
        return response.data
      })
      .catch((error) => {
        console.log('NewLogin: Model enviada ->', model, error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Save', error, 'main', 3000)
      })
  }

  const editModel = async (model) => {
    console.log('editModel', model)
    return await services()
      .put(`${baseUrl + service}`, model)
      .then((response) => {
        if(response.status == 200){
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Success, 'Sucesso!', 'Salvo em banco de dados', 'main', 2000)
        }
        return response.data
      })
      .catch((error) => {
        console.log('Put: Model enviada ->', model)
        console.log('Erro Put catch (error)', error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
      })
  }

  const deleteModel = async (model) => {
    return await services()
      .delete(`${baseUrl + service}/${model.Id}`)
      .then((response) => {
        if(response.status == 200){
          store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Info, 'Deletado com sucesso!', 'Excluido do banco de dados', 'main', 2000)
        }
        return response
      })
      .catch((error) => {
        console.log('Delete: id enviado ->', model.Id)
        console.log('Erro Delete catch (error)', error)
        store.prop.toastMessage = store.methods.toastMessage(EToastSeverity.Error, 'Falha!', error, 'main', 3000)
      })
  }

  return {
    getAll,
    getById,
    saveModel,
    editModel,
    deleteModel,
    newPerson,
    login
  }
}
