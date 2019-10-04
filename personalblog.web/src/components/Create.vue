<template>
  <div class="create">
    <form @submit="postBlog">
      <textarea class="form-control" v-model="title" placeholder="Enter Title"></textarea>
      <!-- <textarea class="form-control" v-model="content" placeholder="Enter Summary"></textarea> -->
      <ckeditor :editor="editor" v-model="content" :config="editorConfig"></ckeditor>
      <button class="btn btn-success">Submit</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

import ClassicEditor from "@ckeditor/ckeditor5-editor-classic/src/classiceditor";
import EssentialsPlugin from "@ckeditor/ckeditor5-essentials/src/essentials";
import UploadAdapterPlugin from "@ckeditor/ckeditor5-adapter-ckfinder/src/uploadadapter";
import AutoformatPlugin from "@ckeditor/ckeditor5-autoformat/src/autoformat";
import BoldPlugin from "@ckeditor/ckeditor5-basic-styles/src/bold";
import ItalicPlugin from "@ckeditor/ckeditor5-basic-styles/src/italic";
import BlockQuotePlugin from "@ckeditor/ckeditor5-block-quote/src/blockquote";
import EasyImagePlugin from "@ckeditor/ckeditor5-easy-image/src/easyimage";
import HeadingPlugin from "@ckeditor/ckeditor5-heading/src/heading";
import ImagePlugin from "@ckeditor/ckeditor5-image/src/image";
import ImageCaptionPlugin from "@ckeditor/ckeditor5-image/src/imagecaption";
import ImageStylePlugin from "@ckeditor/ckeditor5-image/src/imagestyle";
import ImageToolbarPlugin from "@ckeditor/ckeditor5-image/src/imagetoolbar";
import ImageUploadPlugin from "@ckeditor/ckeditor5-image/src/imageupload";
import LinkPlugin from "@ckeditor/ckeditor5-link/src/link";
import ListPlugin from "@ckeditor/ckeditor5-list/src/list";
import ParagraphPlugin from "@ckeditor/ckeditor5-paragraph/src/paragraph";
import SimpleUploadAdapter from "@ckeditor/ckeditor5-upload/src/adapters/simpleuploadadapter";

export default {
  name: "create",
  data() {
    return {
      title: "",
      content: "",
      editor: ClassicEditor,
      editorConfig: {
        plugins: [
          EssentialsPlugin,
          UploadAdapterPlugin,
          AutoformatPlugin,
          BoldPlugin,
          ItalicPlugin,
          BlockQuotePlugin,
          EasyImagePlugin,
          HeadingPlugin,
          ImagePlugin,
          ImageCaptionPlugin,
          ImageStylePlugin,
          ImageToolbarPlugin,
          ImageUploadPlugin,
          LinkPlugin,
          ListPlugin,
          ParagraphPlugin,
          SimpleUploadAdapter
        ],
        toolbar: {
          items: [
            "heading",
            "|",
            "bold",
            "italic",
            "link",
            "bulletedList",
            "numberedList",
            "imageUpload",
            "blockQuote",
            "undo",
            "redo"
          ]
        },
        image: {
          toolbar: [
            "imageStyle:full",
            "imageStyle:side",
            "|",
            "imageTextAlternative"
          ]
        },
        simpleUpload: {
          // The URL that the images are uploaded to.
          uploadUrl: "https://localhost:5001/api/image"
        }
      }
    };
  },
  methods: {
    postBlog(e) {
      e.preventDefault();
      const path = "https://localhost:5001/api/blogs";
      axios
        .post(path, {
          title: this.title,
          content: this.content
        })
        .then(res => {
          this.blog = res.data;
        })
        .catch(error => {
          // eslint-disable-next-line
          console.error(error);
        });
    }
  }
};
</script>

<style scoped>
</style>
