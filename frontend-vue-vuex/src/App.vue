<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <!-- <div class="container"> -->

          <router-link to="/" class="nav-link navbar-brand mt-0 pt-0 mb-0 pb-0 mr-0 pr-0">
            {{ this.siteTitle }}
          </router-link>
          <div class="nav-link mt-2 pt-0 mb-0 pb-0 pr-5" style="color: #fff;font-family: 'Lato', sans-serif;">Biticook</div>

        <div class="navbar-nav mr-auto">
          <li class="nav-item mr-3">
            <router-link to="/home" class="nav-link">
              <font-awesome-icon icon="home" />&nbsp;トップ
            </router-link>
          </li>
          <li class="nav-item">
            <router-link v-if="currentUser" to="/profile" class="nav-link">
              <font-awesome-icon icon="file" />&nbsp;プロフィール
            </router-link>
          </li>
          <li class="nav-item">
            <router-link v-if="currentUser" to="/disaster-stocks/list" class="nav-link">
              <font-awesome-icon icon="file" />&nbsp;検索一覧
            </router-link>
          </li>
        </div>

        <div v-if="!currentUser" class="navbar-nav ml-auto">
          <li class="nav-item mr-3">
            <router-link to="/register" class="nav-link">
              <font-awesome-icon icon="user-plus" />&nbsp;登録
            </router-link>
          </li>
          <li class="nav-item">
            <router-link to="/login" class="nav-link">
              <font-awesome-icon icon="sign-in-alt" />ログイン
            </router-link>
          </li>
        </div>

        <div v-if="currentUser" class="navbar-nav ml-auto">
          <li class="nav-item mr-3">
            <router-link to="/profile" class="nav-link">
              <font-awesome-icon icon="user" />
              &nbsp;{{ currentUser.username }}
            </router-link>
          </li>
          <li class="nav-item">
            <a class="nav-link" href @click.prevent="logOut">
              <font-awesome-icon icon="sign-out-alt" />&nbsp;ログアウト
            </a>
          </li>
        </div>
      <!-- </div> -->
    </nav>

    <div class="container">
      <router-view />
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      siteTitle: '災害備蓄マスタ管理',
    };
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  methods: {
    logOut() {
      this.$store.dispatch('auth/logout');
      this.$router.push('/login');
    },
    createPageTitle: function (routeInstance) {
      // タイトルを設定
      if (routeInstance.meta.title) {
        const setTitle = `${routeInstance.meta.title} | ${this.siteTitle}`;
        document.title = setTitle;
      } else {
        document.title = this.siteTitle;
      }

      // メタタグdescription設定
      const setDesc = routeInstance.meta.desc ? routeInstance.meta.desc : '';

      const elem = document.querySelector("meta[name='description']");
      elem.setAttribute('content', setDesc);
    },
  },
  mounted: function () {
    var routeInstance = this.$route;
    this.createPageTitle(routeInstance);
  },
  watch: {
    $route(routeInstance, from) {
      this.createPageTitle(routeInstance);
    },
  },
};
</script>
