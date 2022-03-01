export * from './base.service'
import axios from 'axios'

export default ({ requiresAuth = true } = {}) => {
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


  if (requiresAuth) {
    const jwtToken = localStorage.getItem('mp_auth')
    options.headers.Authorization = 'Bearer ' + jwtToken as string
  }
  // else {
    // options.baseURL = 'https://localhost:5020/'
    // const jwtToken = localStorage.getItem('mp_auth')
    // options.headers.Authorization = 'Bearer ' + jwtToken as string
  // }
  const instance = axios.create(options)
  return instance
}
