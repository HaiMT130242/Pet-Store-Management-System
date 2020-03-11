﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.Object
{
    class Comment
    {
        private int cmt_id;
        private String cmt_content;
        private String cmt_published;
        private String cmt_status;
        private int p_id;
        private int u_id;
        private String u_name;
        private String p_name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmt_id"></param>
        /// <param name="cmt_content"></param>
        /// <param name="cmt_published"></param>
        /// <param name="cmt_Status"></param>
        /// <param name="p_id"></param>
        /// <param name="u_id"></param>
        public Comment(int cmt_id, String cmt_content, String cmt_published,
                              String cmt_Status, int p_id, int u_id)
        {
            this.cmt_id = cmt_id;
            this.cmt_content = cmt_content;
            this.cmt_published = cmt_published;
            this.cmt_status = cmt_Status;
            this.p_id = p_id;
            this.u_id = u_id;
        }
        public int CommentID
        {
            set
            {
                this.cmt_id = value;
            }
            get
            {
                return cmt_id;
            }
        }

        public String CommentContent
        {
            set
            {
                this.cmt_content = value;
            }
            get
            {
                return cmt_content;
            }
        }

        public String CommentPublished
        {
            set
            {
                this.cmt_published = value;
            }
            get
            {
                return cmt_published;
            }
        }

        public String CommentStatus
        {
            set
            {
                this.cmt_status = value;
            }
            get
            {
                return cmt_status;
            }
        }
        public int UserID
        {
            set
            {
                this.u_id = value;
            }
            get
            {
                return u_id;
            }
        }

        public int PetID
        {
            set
            {
                this.p_id = value;
            }
            get
            {
                return p_id;
            }
        }

        public String UserName
        {
            set
            {
                this.u_name = value;
            }
            get
            {
                return u_name;
            }
        }

        public String PetName
        {
            set
            {
                this.p_name = value;
            }
            get
            {
                return p_name;
            }
        }
    }
}