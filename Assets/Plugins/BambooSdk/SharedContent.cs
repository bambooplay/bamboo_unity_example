
using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID && !UNITY_EDITOR
using UnityEngine;
using System.Runtime.InteropServices;
#endif

public class SharedContent {
    public const int SHARED_APP = 1;
    public const int SHARED_LINK = 2;
    public const int SHARED_PICTURE_PATH = 3;
    public const int SHARED_PICTURE_URL = 4;
    public const int SHARED_VIDEO = 5;
    private Builder builder;

    public SharedContent(Builder builder) {
        this.builder = builder;
    }

    public static Builder newBuilder() {
        Builder builder = new Builder();
        return builder;
    }

    public int getSharedType() {
        return builder.mSharedType;
    }

    public string getText() {
        return builder.text;
    }

    public LinkContent getLinkContent() {
        return builder.linkContent;
    }

    public VideoContent getVideoContent() {
        return builder.videoContent;
    }

    public List<PictureUrlContent> getPictureUrlList() {
        return builder.pictureUrlList;
    }

    public List<PictureLocalContent> getPictureLocalList() {
        return builder.pictureLocalList;
    }
}
public class Builder
{
    public int mSharedType;
    public string text;
    public LinkContent linkContent;
    public VideoContent videoContent;
    public List<PictureUrlContent> pictureUrlList;
    public List<PictureLocalContent> pictureLocalList;

    public Builder setText(string text)
    {
        this.text = text;
        return this;
    }

    public Builder sharedApp()
    {
        mSharedType = SharedContent.SHARED_APP;
        return this;
    }

    public Builder shareLink(LinkContent linkContent)
    {
        mSharedType = SharedContent.SHARED_LINK;
        this.linkContent = linkContent;
        return this;
    }

    public Builder addPictureUrl(PictureUrlContent pictureUrlContent)
    {
        if (pictureUrlContent == null)
        {
            return this;
        }
        mSharedType = SharedContent.SHARED_PICTURE_URL;
        if (pictureUrlList == null)
        {
            pictureUrlList = new List<PictureUrlContent>();
        }
        pictureUrlList.Add(pictureUrlContent);
        return this;
    }

    public Builder addPictureLocal(PictureLocalContent pictureLocalContent)
    {
        if (pictureLocalContent == null)
        {
            return this;
        }
        mSharedType = SharedContent.SHARED_PICTURE_PATH;
        if (pictureLocalList == null)
        {
            pictureLocalList = new List<PictureLocalContent>();
        }
        pictureLocalList.Add(pictureLocalContent);
        return this;
    }

    public Builder addVideo(VideoContent videoContent)
    {
        mSharedType = SharedContent.SHARED_VIDEO;
        this.videoContent = videoContent;
        return this;
    }

    public SharedContent build()
    {
        return new SharedContent(this);
    }
}

public class LinkContent
{
    private string url;

    public void setUrl(string url)
    {
        this.url = url;
    }

    public string getUrl()
    {
        return url;
    }
}

public class PictureLocalContent
{
    private string path;

    public void setPath(string path)
    {
        this.path = path;
    }

    public string getPath()
    {
        return path;
    }
}

public class PictureUrlContent
{
    private string url;

    public void setUrl(string url)
    {
        this.url = url;
    }

    public string getUrl()
    {
        return url;
    }
}

public class VideoContent
{
    private string description;
    private string videoPath;

    public void setDescription(string description)
    {
        this.description = description;
    }

    public void setVideoPath(string videoPath)
    {
        this.videoPath = videoPath;
    }

    public string getDescription()
    {
        return description;
    }

    public string getVideoPath()
    {
        return videoPath;
    }
}