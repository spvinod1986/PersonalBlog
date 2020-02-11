<template>
  <div class="edit">
    <form @submit="putBlog">
      <span>
        <time datetime="2019-09-30">30 SEP 2019</time>
      </span>
      <textarea class="form-control title" v-model="title"></textarea>
      <editor v-bind:content="content" @onUpdate="onEditorContentUpdate" :key="id"></editor>
      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";
import editor from "./Editor";

export default {
  name: "blog",
  components: {
    editor
  },
  data() {
    return {
      id: "",
      title: "",
      content: ""
    };
  },
  methods: {
    getBlog() {
      const path =
        process.env.VUE_APP_API_PATH + "blogs/" + this.$route.params.id;
      axios
        .get(path)
        .then(res => {
          this.id = res.data.id;
          this.title = res.data.title;
          this.content = res.data.content;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    async putBlog(e) {
      e.preventDefault();
      const path =
        process.env.VUE_APP_API_PATH + "blogs/" + this.$route.params.id;
      const token = await this.$auth.getTokenSilently();
      axios
        .put(
          path,
          {
            id: this.$route.params.id,
            title: this.title,
            content: this.content
          },
          {
            headers: {
              Authorization: `Bearer ${token}`
            }
          }
        )
        .then(res => {
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    },
    onEditorContentUpdate(editorContent) {
      this.content = editorContent;
    }
  },
  created() {
    this.getBlog();
  }
};
</script>

<style scoped>
.title {
  border: hidden;
  font-size: 2rem;
  font-weight: 600;
  color: #222222;
}
</style>
