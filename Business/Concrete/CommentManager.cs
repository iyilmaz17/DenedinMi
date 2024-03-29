﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentService)
        {
            _commentDal = commentService;
        }
        public IResult Add(Comment comment)
        {
            //var context = new ValidationContext<Comment>(comment);
            //CommentValidator commentValidator = new CommentValidator();
            //var result = commentValidator.Validate(context);
            //if (!result.IsValid)
            //{
            comment.CreatedDate = DateTime.Now;
                _commentDal.Add(comment);
            //}
            return new SuccessResult(Messages.CommentAdd);
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult(Messages.CommentDelete);

        }

        public IDataResult<List<Comment>> GetAllByProductId(int id)
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(c=>c.ProductId ==id));
        }

        public IDataResult<Comment> GetById(int commentId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.Id == commentId));

        }

        public IDataResult<Comment> GetByProductId(int productId)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<CommentAVG>> GetCommentAvg()
        {
            return new SuccessDataResult<List<CommentAVG>>(_commentDal.GetCommentDetail());
        }

        public IDataResult<CommentAVG> GetCommentDetailByProductId(int productId)
        {
            return new SuccessDataResult<CommentAVG>(_commentDal.GetCommentDetailByProductId(productId));
        }

        public IDataResult<CommentAVG> GetCommentDetailByProductIdWithMaxUserCount()
        {
            return new SuccessDataResult<CommentAVG>(_commentDal.GetCommentDetailByProductIdWithMaxUserCount());
        }

        public IDataResult<List<Comment>> GetCommentList()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll());
        }

        public IResult Update(Comment comment)
        {
            return new SuccessResult(Messages.CommentUpdate);
        }
    }
}
