export * from './base.service'
import axios from 'axios'

export default () => {
  const options = {
    baseURL: '',
    headers: {
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': true,
      Authorization: ''
    },
    timeout: 60 * 1000
  }
  options.baseURL = 'https://localhost:5020/'
  options.headers.Authorization = `Bearer ${localStorage.getItem('Authorization')}`

  return axios.create(options)
}
