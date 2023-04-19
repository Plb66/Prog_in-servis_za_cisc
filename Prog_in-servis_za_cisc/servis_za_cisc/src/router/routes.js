
const routes = [
  {
    path: '/',
    component: () => import('layouts/NewLayout'),
    children: [
      {
        path: ''
      ,
       component: () => import('pages/IndexPage.vue')
      },
      {
        path: 'izbornik_admin'
      ,
       component: () => import('pages/izbornikAdmin.vue')
      }
    ]
  },

  // Always leave this as last one,
  // but you can also remove it
  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
